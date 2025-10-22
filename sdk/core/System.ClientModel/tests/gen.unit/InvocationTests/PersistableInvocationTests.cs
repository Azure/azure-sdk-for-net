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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", jsonModel.Modifier);
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual(InvocationTestBase.s_modelExpectations[jsonModel.Type.Name].Context, jsonModel.ContextType);
            Assert.IsNull(jsonModel.PersistableModelProxy);
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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", jsonModel.Modifier);
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual(InvocationTestBase.s_modelExpectations[jsonModel.Type.Name].Context, jsonModel.ContextType);
            Assert.IsNull(jsonModel.PersistableModelProxy);
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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", jsonModel.Modifier);
            InvocationTestBase.AssertJsonModel(jsonModel.Type);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual(InvocationTestBase.s_modelExpectations[jsonModel.Type.Name].Context, jsonModel.ContextType);
            Assert.IsNull(jsonModel.PersistableModelProxy);
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

            Assert.IsNotNull(depResult.GenerationSpec);
            Assert.AreEqual("LocalContext", depResult.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestDependency", depResult.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, depResult.Diagnostics.Length);
            Assert.AreEqual("public", depResult.GenerationSpec!.Modifier);
            Assert.AreEqual(1, depResult.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, depResult.GenerationSpec.ReferencedContexts.Count);

            var depJsonModel = depResult.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", depJsonModel.Modifier);
            InvocationTestBase.AssertJsonModel(depJsonModel.Type, expectedNamespace: "TestDependency");
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, depJsonModel.Kind);
            Assert.AreEqual("LocalContext", depJsonModel.ContextType.Name);
            Assert.AreEqual("TestDependency", depJsonModel.ContextType.Namespace);
            Assert.IsNull(depJsonModel.PersistableModelProxy);

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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(1, result.GenerationSpec.ReferencedContexts.Count);

            var jsonModel = result.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", jsonModel.Modifier);
            InvocationTestBase.AssertJsonModel(jsonModel.Type, expectedNamespace: "TestDependency");
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, jsonModel.Kind);
            Assert.AreEqual("LocalContext", jsonModel.ContextType.Name);
            Assert.AreEqual("TestDependency", jsonModel.ContextType.Namespace);
            Assert.IsNull(jsonModel.PersistableModelProxy);
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

            Assert.IsNull(depResult.GenerationSpec);

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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual("public", result.GenerationSpec!.Modifier);
            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);
        }
    }
}
