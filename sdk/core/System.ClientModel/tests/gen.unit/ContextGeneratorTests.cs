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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            AssertJsonModel(jsonModel.Type);
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType, Is.EqualTo(s_modelExpectations[jsonModel.Type.Name].Context));
            Assert.That(jsonModel.PersistableModelProxy, Is.Not.Null);
            var unknownJsonModel = jsonModel.PersistableModelProxy;
            Assert.That(unknownJsonModel!.Name, Is.EqualTo("UnknownJsonModel"));
            Assert.That(unknownJsonModel.Namespace, Is.EqualTo("TestProject"));

            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Name, Is.EqualTo("UnknownJsonModel"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            if (expectedDiag)
            {
                Assert.That(result.Diagnostics.Length, Is.EqualTo(1));
                Assert.That(result.Diagnostics[0].Id, Is.EqualTo(ModelReaderWriterContextGenerator.DiagnosticDescriptors.TypeMustHaveParameterlessConstructor.Id));

                Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            }
            else
            {
                Assert.That(result.Diagnostics.Length, Is.EqualTo(0));

                Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
                Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("PersistableModel"));
                Assert.That(result.GenerationSpec.TypeBuilders[0].Modifier, Is.EqualTo("internal"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => $"{t.Type.Namespace}.{t.Type.Name}", t => t);
            Assert.That(dict.ContainsKey("TestProject.JsonModel"), Is.True);
            Assert.That(dict.ContainsKey("TestProject2.JsonModel"), Is.True);
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(1));
            Assert.That(result.Diagnostics[0].Id, Is.EqualTo(ModelReaderWriterContextGenerator.DiagnosticDescriptors.AbstractTypeWithoutProxy.Id));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("UnknownJsonModel"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("_Type.Foo"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            InvocationTestBase.AssertJsonModel(result.GenerationSpec.TypeBuilders[0].Type, "_Type.Foo");
        }

        [Test]
        public void ValidateRoslynVersion()
        {
            Assembly roslynAssembly = typeof(Compilation).Assembly;
            Version expectedVersion = new Version(4, 3, 0, 0);
            Version? actualVersion = roslynAssembly.GetName().Version;

            //This version is required for the source generator to work correctly.
            Assert.That(actualVersion, Is.EqualTo(expectedVersion),
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
            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("MyLocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
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
            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
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

            Assert.That(result.GenerationSpec, Is.Null);
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

            Assert.That(result.GenerationSpec, Is.Null);
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo(modifier));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo(modifier));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.TypeBuilders[0].ContextType.Name, Is.EqualTo("TestClientModelReaderWriterContext"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("AvailabilitySetData"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Namespace, Is.EqualTo("System.ClientModel.Tests.Client.Models.ResourceManager.Compute"));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts[0].Name, Is.EqualTo("TestClientModelReaderWriterContext"));
            Assert.That(result.GenerationSpec.ReferencedContexts[0].Namespace, Is.EqualTo("System.ClientModel.Tests.ModelReaderWriterTests"));

            //we shouldn't make a builder just add the reference to forward to TestClientModelReaderWriterContext
            Assert.That(newCompilation.GetTypeByMetadataName($"{result.GenerationSpec.TypeBuilders[0].Type.TypeCaseName}Builder"), Is.Null);
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

            Assert.That(result.GenerationSpec, Is.Null);
            Assert.That(result.Diagnostics.Length, Is.EqualTo(1));
            Assert.That(result.Diagnostics[0].Id, Is.EqualTo(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id));
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

            Assert.That(result.GenerationSpec, Is.Null);
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
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

            Assert.That(result.GenerationSpec, Is.Null);
            Assert.That(result.Diagnostics.Length, Is.EqualTo(1));
            Assert.That(result.Diagnostics[0].Id, Is.EqualTo(ModelReaderWriterContextGenerator.DiagnosticDescriptors.ContextMustBePartial.Id));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(1));
            Assert.That(result.Diagnostics[0].Id, Is.EqualTo(ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(2));

            var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => $"{t.Type.GetInnerItemType().Namespace}.{t.Type.Name}", t => t);
            ListTests.AssertList(s_modelExpectations[JsonModel], false, dict);

            Assert.That(dict.TryGetValue($"TestProject.{JsonModel}", out var item), Is.True);
            AssertJsonModel(item!.Type);

            Assert.That(result.Diagnostics.Length, Is.EqualTo(1));
            Assert.That(result.Diagnostics[0].Id, Is.EqualTo(ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id));
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

            Assert.That(depResult.GenerationSpec, Is.Not.Null);
            Assert.That(depResult.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(depResult.GenerationSpec.Type.Namespace, Is.EqualTo("TestDependency"));
            Assert.That(depResult.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(depResult.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(depResult.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));

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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("MyLocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(1));

            var myLocalContext = newCompilation.GetTypeByMetadataName("TestProject.MyLocalContext");
            Assert.That(myLocalContext, Is.Not.Null, "MyLocalContext should not be null.");

            var referenceContextFiled = myLocalContext!.GetMembers("s_referenceContexts")
                .OfType<IFieldSymbol>()
                .FirstOrDefault(f => f.IsStatic);
            Assert.That(referenceContextFiled, Is.Not.Null, "s_referenceContexts field should not be null.");

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
            Assert.That(foundInitializer, Is.True, "s_referenceContexts should be initialized with TestDependency.LocalContext.Default");
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(isError ? 0 : 1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            if (!isError)
            {
                Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("JsonModel"));
                Assert.That(result.GenerationSpec.TypeBuilders[0].Modifier, Is.EqualTo("internal"));
                Assert.That(result.GenerationSpec.TypeBuilders[0].Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(isError ? 0 : collectionType == "JsonModel[][]" ? 3 : 2));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            if (!isError)
            {
                var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);

                Assert.That(dict.TryGetValue("JsonModel", out var jsonModelBuilder), Is.True);
                Assert.That(jsonModelBuilder!.Type.Name, Is.EqualTo("JsonModel"));
                Assert.That(jsonModelBuilder.Type.Namespace, Is.EqualTo("TestProject"));
                Assert.That(jsonModelBuilder.Modifier, Is.EqualTo("internal"));
                Assert.That(jsonModelBuilder.Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));

                Assert.That(dict.TryGetValue(collectionType, out var collectionBuilder), Is.True);
                Assert.That(collectionBuilder!.Type.Name, Is.EqualTo(collectionType));
                if (collectionType == "JsonModel[]" || collectionType == "JsonModel[,]" || collectionType == "JsonModel[][]")
                {
                    Assert.That(collectionBuilder.Type.Namespace, Is.EqualTo("TestProject"));
                }
                else if (collectionType == "ReadOnlyMemory<JsonModel>")
                {
                    Assert.That(collectionBuilder.Type.Namespace, Is.EqualTo("System"));
                }
                else
                {
                    Assert.That(collectionBuilder.Type.Namespace, Is.EqualTo("System.Collections.Generic"));
                }
                Assert.That(collectionBuilder.Modifier, Is.EqualTo("internal"));
                Assert.That(collectionBuilder.Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));
                if (collectionType == "JsonModel[][]")
                {
                    Assert.That(collectionBuilder.Type.ItemType!.Name, Is.EqualTo("JsonModel[]"));
                    Assert.That(collectionBuilder.Type.ItemType!.Namespace, Is.EqualTo("TestProject"));

                    Assert.That(dict.TryGetValue("JsonModel[]", out var jsonModelArrayBuilder), Is.True);
                    Assert.That(jsonModelArrayBuilder!.Type.Name, Is.EqualTo("JsonModel[]"));
                    Assert.That(jsonModelArrayBuilder.Type.Namespace, Is.EqualTo("TestProject"));
                    Assert.That(jsonModelArrayBuilder.Modifier, Is.EqualTo("internal"));
                    Assert.That(jsonModelArrayBuilder.Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));

                    Assert.That(jsonModelArrayBuilder.Type.ItemType!.Name, Is.EqualTo("JsonModel"));
                    Assert.That(jsonModelArrayBuilder.Type.ItemType!.Namespace, Is.EqualTo("TestProject"));
                    Assert.That(jsonModelArrayBuilder.Type.ItemType!.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));
                }
                else
                {
                    Assert.That(collectionBuilder.Type.ItemType!.Name, Is.EqualTo("JsonModel"));
                    Assert.That(collectionBuilder.Type.ItemType!.Namespace, Is.EqualTo("TestProject"));
                    Assert.That(collectionBuilder.Type.ItemType!.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(3));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("JsonModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Name, Is.EqualTo("Jsonmodel"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.TypeBuilders[2].Type.Name, Is.EqualTo("JsonmodeL"));
            Assert.That(result.GenerationSpec.TypeBuilders[2].Type.Namespace, Is.EqualTo("TestProject"));

            Assert.That(generatedSources[1].HintName, Is.EqualTo("TestProject_JsonModel_Builder.g.cs"));
            Assert.That(generatedSources[2].HintName, Is.EqualTo("TestProject_Jsonmodel_Builder_1.g.cs"));
            Assert.That(generatedSources[3].HintName, Is.EqualTo("TestProject_JsonmodeL_Builder_2.g.cs"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("JsonModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Namespace, Is.EqualTo("TestProject"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            // Order should match the discovery order (first JsonModel, then JsonModel2).
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("JsonModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Name, Is.EqualTo("JsonModel2"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Namespace, Is.EqualTo("TestProject"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("JsonModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Name, Is.EqualTo("JsonModel2"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.Namespace, Is.EqualTo("TestProject"));
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
            Assert.That(result.GenerationSpec, Is.Not.Null);

            // Verify the new compilation still has warnings for direct usage but not for generated code
            var diagnostics = newCompilation.GetDiagnostics();
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
            Assert.That(errors.Length, Is.EqualTo(0), "Compilation should not have errors");

            // Check for experimental warnings - should still have them for direct usage in TestUsage class
            var experimentalWarnings = diagnostics
                .Where(d => (d.Id == "TEST001" || d.Id == "TEST002") && !d.Location.IsInSource).ToArray();
            Assert.That(experimentalWarnings.Length, Is.EqualTo(0), "Generated code should not produce experimental warnings");

            // Check the context file for pragma suppressions in the constructor
            var contextSource = generatedSources.First(s => s.HintName == "LocalContext.g.cs");
            var contextText = contextSource.SourceText.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

            var startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST001"));
            Assert.That(startIndex >= 0, Is.True, "Could not find #pragma warning disable TEST001");

            Assert.That(startIndex + 2 < contextText.Count, Is.True, "Not enough lines after pragma disable");
            Assert.That(contextText[startIndex + 1], Does.Contain("_typeBuilderFactories.Add(typeof(global::TestProject.JsonModel)"));
            Assert.That(contextText[startIndex + 2], Does.Contain("#pragma warning restore TEST001"));

            startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST002"));
            Assert.That(startIndex >= 0, Is.True, "Could not find #pragma warning disable TEST002");
            Assert.That(contextText[startIndex + 1], Does.Contain("_typeBuilderFactories.Add(typeof(global::TestProject.OtherModel)"));
            Assert.That(contextText[startIndex + 2], Does.Contain("#pragma warning restore TEST002"));

            // Also check the builder files
            var jsonModelBuilder = generatedSources.First(s => s.HintName.Contains("JsonModel_Builder"));
            var jsonModelText = jsonModelBuilder.SourceText.ToString();
            Assert.That(jsonModelText, Does.Contain("#pragma warning disable TEST001"));
            Assert.That(jsonModelText, Does.Contain("#pragma warning restore TEST001"));

            var otherModelBuilder = generatedSources.First(s => s.HintName.Contains("OtherModel_Builder"));
            var otherModelText = otherModelBuilder.SourceText.ToString();
            Assert.That(otherModelText, Does.Contain("#pragma warning disable TEST002"));
            Assert.That(otherModelText, Does.Contain("#pragma warning restore TEST002"));

            Assert.That(result.GenerationSpec!.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.ExperimentalDiagnosticId, Is.EqualTo("TEST002"));
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
            Assert.That(result.GenerationSpec, Is.Not.Null);

            // Verify the new compilation still has warnings for direct usage but not for generated code
            var diagnostics = newCompilation.GetDiagnostics();
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
            Assert.That(errors.Length, Is.EqualTo(0), "Compilation should not have errors");

            // Check for experimental warnings - should still have them for direct usage in TestUsage class
            var experimentalWarnings = diagnostics
                .Where(d => (d.Id == "TEST001") && !d.Location.IsInSource).ToArray();
            Assert.That(experimentalWarnings.Length, Is.EqualTo(0), "Generated code should not produce experimental warnings");

            // Check the context file for pragma suppressions in the constructor
            var contextSource = generatedSources.First(s => s.HintName == "LocalContext.g.cs");
            var contextText = contextSource.SourceText.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

            var startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST001"));
            Assert.That(startIndex >= 0, Is.True, "Could not find #pragma warning disable TEST001");

            Assert.That(startIndex + 2 < contextText.Count, Is.True, "Not enough lines after pragma disable");
            Assert.That(contextText[startIndex + 1], Does.Contain("_typeBuilderFactories.Add(typeof(global::TestProject.JsonModel)"));
            Assert.That(contextText[startIndex + 2], Does.Contain("#pragma warning restore TEST001"));

            // Also check the builder files
            var jsonModelBuilder = generatedSources.First(s => s.HintName.Contains("JsonModel_Builder"));
            var jsonModelText = jsonModelBuilder.SourceText.ToString();
            Assert.That(jsonModelText, Does.Contain("#pragma warning disable TEST001"));
            Assert.That(jsonModelText, Does.Contain("#pragma warning restore TEST001"));

            var otherModelBuilder = generatedSources.First(s => s.HintName.Contains("OtherModel_Builder"));
            var otherModelText = otherModelBuilder.SourceText.ToString();
            Assert.That(otherModelText, Does.Not.Contain("#pragma warning disable"));
            Assert.That(otherModelText, Does.Not.Contain("#pragma warning restore"));

            Assert.That(result.GenerationSpec!.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.ExperimentalDiagnosticId, Is.Null);
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
            Assert.That(result.GenerationSpec, Is.Not.Null);

            // Verify the new compilation still has warnings for direct usage but not for generated code
            var diagnostics = newCompilation.GetDiagnostics();
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
            Assert.That(errors.Length, Is.EqualTo(0), "Compilation should not have errors");

            // Check for experimental warnings - should still have them for direct usage in TestUsage class
            var experimentalWarnings = diagnostics
                .Where(d => (d.Id == "TEST001") && !d.Location.IsInSource).ToArray();
            Assert.That(experimentalWarnings.Length, Is.EqualTo(0), "Generated code should not produce experimental warnings");

            // Check the context file for pragma suppressions in the constructor
            var contextSource = generatedSources.First(s => s.HintName == "LocalContext.g.cs");
            var contextText = contextSource.SourceText.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

            var startIndex = contextText.FindIndex(line => line.Contains("#pragma warning disable TEST001"));
            Assert.That(startIndex >= 0, Is.True, "Could not find #pragma warning disable TEST001");

            Assert.That(startIndex + 2 < contextText.Count, Is.True, "Not enough lines after pragma disable");
            Assert.That(contextText[startIndex + 1], Does.Contain("_typeBuilderFactories.Add(typeof(global::TestProject.JsonModel)"));
            Assert.That(contextText[startIndex + 2], Does.Contain("#pragma warning restore TEST001"));

            // Also check the builder files
            var jsonModelBuilder = generatedSources.First(s => s.HintName.Contains("JsonModel_Builder"));
            var jsonModelText = jsonModelBuilder.SourceText.ToString();
            Assert.That(jsonModelText, Does.Contain("#pragma warning disable TEST001"));
            Assert.That(jsonModelText, Does.Contain("#pragma warning restore TEST001"));

            var otherModelBuilder = generatedSources.First(s => s.HintName.Contains("OtherModel_Builder"));
            var otherModelText = otherModelBuilder.SourceText.ToString();
            Assert.That(otherModelText, Does.Contain("#pragma warning disable CS0618"));
            Assert.That(otherModelText, Does.Contain("#pragma warning restore CS0618"));

            Assert.That(result.GenerationSpec!.TypeBuilders.Count, Is.EqualTo(2));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));
            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.ExperimentalDiagnosticId, Is.Null);

            Assert.That(result.GenerationSpec.TypeBuilders[1].Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.Warning));
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

            Assert.That(depResult.GenerationSpec, Is.Not.Null);
            Assert.That(depResult.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(depResult.GenerationSpec.Type.Namespace, Is.EqualTo("TestDependency"));
            Assert.That(depResult.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(depResult.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(depResult.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));

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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("MyLocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(1));

            var myLocalContext = newCompilation.GetTypeByMetadataName("TestProject.MyLocalContext");
            Assert.That(myLocalContext, Is.Not.Null, "MyLocalContext should not be null.");

            var referenceContextFiled = myLocalContext!.GetMembers("s_referenceContexts")
                .OfType<IFieldSymbol>()
                .FirstOrDefault(f => f.IsStatic);
            Assert.That(referenceContextFiled, Is.Not.Null, "s_referenceContexts field should not be null.");
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count,
                Is.EqualTo(collectionType == "JsonModel[][]" ? 3 : 2));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var dict = result.GenerationSpec.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);

            Assert.That(dict.TryGetValue("JsonModel", out var jsonModelBuilder), Is.True);
            Assert.That(jsonModelBuilder!.Type.Name, Is.EqualTo("JsonModel"));
            Assert.That(jsonModelBuilder.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(jsonModelBuilder.Modifier, Is.EqualTo("internal"));
            Assert.That(jsonModelBuilder.Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.None));
            Assert.That(jsonModelBuilder.Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));

            Assert.That(dict.TryGetValue(collectionType, out var collectionBuilder), Is.True);
            Assert.That(collectionBuilder!.Type.Name, Is.EqualTo(collectionType));
            if (collectionType == "JsonModel[]" || collectionType == "JsonModel[,]" ||
                collectionType == "JsonModel[][]")
            {
                Assert.That(collectionBuilder.Type.Namespace, Is.EqualTo("TestProject"));
            }
            else if (collectionType == "ReadOnlyMemory<JsonModel>")
            {
                Assert.That(collectionBuilder.Type.Namespace, Is.EqualTo("System"));
            }
            else
            {
                Assert.That(collectionBuilder.Type.Namespace, Is.EqualTo("System.Collections.Generic"));
            }

            Assert.That(collectionBuilder.Modifier, Is.EqualTo("internal"));
            Assert.That(collectionBuilder.Type.ObsoleteLevel, Is.EqualTo(ObsoleteLevel.None));
            Assert.That(collectionBuilder.Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));
            if (collectionType == "JsonModel[][]")
            {
                Assert.That(collectionBuilder.Type.ItemType!.Name, Is.EqualTo("JsonModel[]"));
                Assert.That(collectionBuilder.Type.ItemType!.Namespace, Is.EqualTo("TestProject"));

                Assert.That(dict.TryGetValue("JsonModel[]", out var jsonModelArrayBuilder), Is.True);
                Assert.That(jsonModelArrayBuilder!.Type.Name, Is.EqualTo("JsonModel[]"));
                Assert.That(jsonModelArrayBuilder.Type.Namespace, Is.EqualTo("TestProject"));
                Assert.That(jsonModelArrayBuilder.Modifier, Is.EqualTo("internal"));
                Assert.That(jsonModelArrayBuilder.Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));

                Assert.That(jsonModelArrayBuilder.Type.ItemType!.Name, Is.EqualTo("JsonModel"));
                Assert.That(jsonModelArrayBuilder.Type.ItemType!.Namespace, Is.EqualTo("TestProject"));
                Assert.That(jsonModelArrayBuilder.Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));
            }
            else
            {
                Assert.That(collectionBuilder.Type.ItemType!.Name, Is.EqualTo("JsonModel"));
                Assert.That(collectionBuilder.Type.ItemType!.Namespace, Is.EqualTo("TestProject"));
                Assert.That(collectionBuilder.Type.ExperimentalDiagnosticId, Is.EqualTo("TEST001"));
            }

            // Also check the builder files
            var builders = generatedSources.Where(s => s.HintName.EndsWith("Builder.g.cs"));
            Assert.That(builders, Is.Not.Empty);
            foreach (var builder in builders)
            {
                var builderText = builder.SourceText.ToString();
                Assert.That(builderText, Does.Contain("#pragma warning disable TEST001"));
                Assert.That(builderText, Does.Contain("#pragma warning restore TEST001"));
            }
        }
#endif
    }
}
