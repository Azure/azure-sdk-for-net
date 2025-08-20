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
            Version expectedVersion = new Version(4, 0, 0, 0);
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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
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

namespace TestProject
{
    {{modifier}} partial class LocalContext : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(
                source,
                additionalReferences:
                [
                    MetadataReference.CreateFromFile(typeof(TestClientModelReaderWriterContext).Assembly.Location)
                ]);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(1, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual("TestClientModelReaderWriterContext", result.GenerationSpec.ReferencedContexts[0].Name);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests", result.GenerationSpec.ReferencedContexts[0].Namespace);
        }

        [Test]
        public void MultipleContextsShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    public partial class LocalContext1 : ModelReaderWriterContext { }
    public partial class LocalContext2 : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, result.Diagnostics[0].Id);
        }

        [Test]
        public void NoPartialShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
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
        public void ValidateDefaultExistsWithNoBuilders()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace TestProject
{
    public partial class LocalContext : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.Diagnostics.Length);

            var localContextSymbol = newCompilation.GetTypeByMetadataName("TestProject.LocalContext");
            Assert.IsNotNull(localContextSymbol);
            var defaultProp = localContextSymbol!.GetMembers("Default")
                .OfType<IPropertySymbol>()
                .FirstOrDefault(p => p.IsStatic);

            Assert.IsNotNull(defaultProp, "Default property should not be null.");

            Assert.IsTrue(SymbolEqualityComparer.Default.Equals(defaultProp!.Type, localContextSymbol));

            Assert.AreEqual(1, localContextSymbol.Constructors.Length);
            var ctor = localContextSymbol.Constructors[0];
            Assert.AreEqual(Accessibility.Private, ctor.DeclaredAccessibility);
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

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

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
                Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
                Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[0].Type.Namespace);
                Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[0].Modifier);
                Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[0].Type.ObsoleteLevel);

                Assert.AreEqual(collectionType, result.GenerationSpec.TypeBuilders[1].Type.Name);
                if (collectionType == "JsonModel[]" || collectionType == "JsonModel[,]" || collectionType == "JsonModel[][]")
                {
                    Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[1].Type.Namespace);
                }
                else if (collectionType == "ReadOnlyMemory<JsonModel>")
                {
                    Assert.AreEqual("System", result.GenerationSpec.TypeBuilders[1].Type.Namespace);
                }
                else
                {
                    Assert.AreEqual("System.Collections.Generic", result.GenerationSpec.TypeBuilders[1].Type.Namespace);
                }
                Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[1].Modifier);
                Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[1].Type.ObsoleteLevel);
                if (collectionType == "JsonModel[][]")
                {
                    Assert.AreEqual("JsonModel[]", result.GenerationSpec.TypeBuilders[1].Type.ItemType!.Name);
                    Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[1].Type.ItemType!.Namespace);

                    Assert.AreEqual("JsonModel[]", result.GenerationSpec.TypeBuilders[2].Type.Name);
                    Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[2].Type.Namespace);
                    Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[2].Modifier);
                    Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[2].Type.ObsoleteLevel);

                    Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[2].Type.ItemType!.Name);
                    Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[2].Type.ItemType!.Namespace);
                    Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[2].Type.ItemType!.ObsoleteLevel);
                }
                else
                {
                    Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[1].Type.ItemType!.Name);
                    Assert.AreEqual("TestProject", result.GenerationSpec.TypeBuilders[1].Type.ItemType!.Namespace);
                    Assert.AreEqual(ObsoleteLevel.Warning, result.GenerationSpec.TypeBuilders[1].Type.ItemType!.ObsoleteLevel);
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
    }
}
