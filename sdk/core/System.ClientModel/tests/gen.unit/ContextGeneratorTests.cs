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
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
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
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
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
    }
}
