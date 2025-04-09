// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class ContextGeneratorTests
    {
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("_Type.Foo", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.ContextFile!.Modifier);
            Assert.AreEqual(1, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);

            InvocationTestBase.AssertJsonModel(result.ContextFile.TypeBuilders[0].Type, "_Type.Foo");
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
            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("MyLocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
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
            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual(1, result.ContextFile.ReferencedContexts.Count);
            Assert.AreEqual("TestClientModelReaderWriterContext", result.ContextFile.ReferencedContexts[0].Name);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests", result.ContextFile.ReferencedContexts[0].Namespace);
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

            Assert.IsNull(result.ContextFile);
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

            Assert.IsNull(result.ContextFile);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
            Assert.AreEqual(0, result.ContextFile.TypeBuilders.Count);
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
    public partial class GoodContext : ModelReaderWriterContext { }

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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("GoodContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
            Assert.AreEqual(2, result.ContextFile.TypeBuilders.Count);

            var dict = result.ContextFile.TypeBuilders.ToDictionary(t => t.Type.Name, t => t);
            ListTests.AssertList(InvocationTestBase.JsonModel, "System.Collections.Generic", (jsonModel) => InvocationTestBase.AssertJsonModel(jsonModel), dict);

            Assert.IsTrue(dict.ContainsKey(InvocationTestBase.JsonModel));
            var item = dict[InvocationTestBase.JsonModel];
            InvocationTestBase.AssertJsonModel(item.Type);

            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id, result.Diagnostics[0].Id);
        }
    }
}
