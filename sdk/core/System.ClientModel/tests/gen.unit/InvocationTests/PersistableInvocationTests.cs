// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    public class PersistableInvocationTests
    {
        [Test]
        public void PersistableReadInvocationTest()
        {
            var source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty);
        }
    }

    public class JsonModel : IJsonModel<JsonModel>
    {
        internal JsonModel() { }
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
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType, Is.EqualTo(InvocationTestBase.s_modelExpectations[jsonModel.Type.Name].Context));
            Assert.That(jsonModel.PersistableModelProxy, Is.Null);
        }

        [Test]
        public void PersistableWriteInvocationTest()
        {
            var source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        public void Call(JsonModel model = null)
        {
            if (model is not null)
            {
                ModelReaderWriter.Write(model);
            }
        }
    }

    public class JsonModel : IJsonModel<JsonModel>
    {
        internal JsonModel() { }
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
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType, Is.EqualTo(InvocationTestBase.s_modelExpectations[jsonModel.Type.Name].Context));
            Assert.That(jsonModel.PersistableModelProxy, Is.Null);
        }

        [Test]
        public void PersistableWriteInvocationViaTemplateTest()
        {
            var source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class Caller
    {
        internal static void Call<T, U>(U model, ModelReaderWriterOptions options)
        {
            ModelReaderWriter.Write(model, options);
        }
    }

    public class JsonModel : IJsonModel<JsonModel>
    {
        internal JsonModel() { }
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
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType, Is.EqualTo(InvocationTestBase.s_modelExpectations[jsonModel.Type.Name].Context));
            Assert.That(jsonModel.PersistableModelProxy, Is.Null);
        }

        [Test]
        public void InteralPersistableReadInvocationFromDependencyTest()
        {
            var depSource =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestAssembly")]

namespace TestDependency
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext { }

    internal class JsonModel : IJsonModel<JsonModel>
    {
        internal JsonModel() { }
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
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
            Assert.That(depResult.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var depJsonModel = depResult.GenerationSpec.TypeBuilders[0];
            Assert.That(depJsonModel.Modifier, Is.EqualTo("internal"));
            InvocationTestBase.AssertJsonModel(depJsonModel.Type, expectedNamespace: "TestDependency");
            Assert.That(depJsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(depJsonModel.ContextType.Name, Is.EqualTo("LocalContext"));
            Assert.That(depJsonModel.ContextType.Namespace, Is.EqualTo("TestDependency"));
            Assert.That(depJsonModel.PersistableModelProxy, Is.Null);

            var source =
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
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty);
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source, additionalReferences: [newDepCompilation.ToMetadataReference()]);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(1));

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.That(jsonModel.Modifier, Is.EqualTo("internal"));
            InvocationTestBase.AssertJsonModel(jsonModel.Type, expectedNamespace: "TestDependency");
            Assert.That(jsonModel.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(jsonModel.ContextType.Name, Is.EqualTo("LocalContext"));
            Assert.That(jsonModel.ContextType.Namespace, Is.EqualTo("TestDependency"));
            Assert.That(jsonModel.PersistableModelProxy, Is.Null);
        }

        [Test]
        public void InteralPersistableReadInvocationFromDependencyWithNoContextTest()
        {
            var depSource =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestAssembly")]

namespace TestDependency
{
    internal class JsonModel : IJsonModel<JsonModel>
    {
        internal JsonModel() { }
        public JsonModel Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();
        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
""";

            Compilation depCompilation = CompilationHelper.CreateCompilation(depSource, assemblyName: "TestDependency");
            var depResult = CompilationHelper.RunSourceGenerator(depCompilation, out var newDepCompilation);

            Assert.That(depResult.GenerationSpec, Is.Null);

            var source =
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
            ModelReaderWriter.Read<JsonModel>(BinaryData.Empty);
        }
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source, additionalReferences: [newDepCompilation.ToMetadataReference()]);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));
        }
    }
}
