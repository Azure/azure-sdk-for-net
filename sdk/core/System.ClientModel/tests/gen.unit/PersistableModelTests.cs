// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class PersistableModelTests
    {
        [TestCase("public")]
        [TestCase("internal")]
        public void PersistableModel(string modifier)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(PersistableModel))]
    {{modifier}} partial class LocalContext : ModelReaderWriterContext
    {
    }

    {{modifier}} class PersistableModel : IPersistableModel<PersistableModel>
    {
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
            Assert.AreEqual(modifier, result.GenerationSpec.Modifier);
            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual("PersistableModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[0].Modifier);
        }

        [TestCase("public")]
        [TestCase("internal")]
        public void JsonModel(string modifier)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(JsonModel))]
    {{modifier}} partial class LocalContext : ModelReaderWriterContext
    {
    }

    {{modifier}} class JsonModel : IJsonModel<JsonModel>
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

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual(modifier, result.GenerationSpec.Modifier);
            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual("JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[0].Modifier);
        }

        [TestCase("public")]
        [TestCase("internal")]
        public void NoContextJsonModel(string modifier)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    {{modifier}} class JsonModel : IJsonModel<JsonModel>
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
        }

        [TestCase("public")]
        [TestCase("internal")]
        public void NoContextPersistableModel(string modifier)
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;

namespace TestProject
{
    {{modifier}} class PersistableModel : IPersistableModel<PersistableModel>
    {
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;

        PersistableModel IPersistableModel<PersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new PersistableModel();
    }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
        }

        [Test]
        public void NestedPersistableModel()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(Wrapper.JsonModel))]
    public partial class LocalContext : ModelReaderWriterContext
    {
    }

    public class Wrapper
    {
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
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual("public", result.GenerationSpec.Modifier);
            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(1, result.GenerationSpec.TypeBuilders.Count);
            Assert.AreEqual("Wrapper.JsonModel", result.GenerationSpec.TypeBuilders[0].Type.Name);
            Assert.AreEqual("Wrapper_JsonModel_", result.GenerationSpec.TypeBuilders[0].Type.TypeCaseName);
            Assert.AreEqual("internal", result.GenerationSpec.TypeBuilders[0].Modifier);

            var modelType = newCompilation.GetTypeByMetadataName("TestProject.Wrapper+JsonModel");
            Assert.IsNotNull(modelType);
        }

        [Test]
        public void NestedPrivatePersistableModelShouldHaveNoBuilder()
        {
            string source =
$$"""
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext : ModelReaderWriterContext
    {
    }

    public class Wrapper
    {
        private class JsonModel : IJsonModel<JsonModel>
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
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation, out var newCompilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual("LocalContext", result.GenerationSpec!.Type.Name);
            Assert.AreEqual("TestProject", result.GenerationSpec.Type.Namespace);
            Assert.AreEqual("public", result.GenerationSpec.Modifier);
            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(0, result.GenerationSpec.TypeBuilders.Count);
        }

        [Test]
        public void PersistableInheritsFromDependencyIEnumerableTest()
        {
            var depSource =
$$"""
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestAssembly")]

namespace TestDependency
{
    public class Model { }
    public partial class CustomCollection : ReadOnlyCollection<Model>
    {
        internal CustomCollection() : base(new List<Model>()) { }
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
    [ModelReaderWriterBuildable(typeof(MyCollection))]
    public partial class LocalContext : ModelReaderWriterContext { }

    public class MyCollection : CustomCollection, IJsonModel<MyCollection>
    {
        internal MyCollection() { }
        public MyCollection Create(ref System.Text.Json.Utf8JsonReader reader, ModelReaderWriterOptions options) => new MyCollection();
        public MyCollection Create(BinaryData data, ModelReaderWriterOptions options) => new MyCollection();
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        public void Write(System.Text.Json.Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
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
            Assert.AreEqual(0, result.GenerationSpec.ReferencedContexts.Count);

            var myCollection = result.GenerationSpec.TypeBuilders[0];
            Assert.AreEqual("internal", myCollection.Modifier);
            Assert.AreEqual("MyCollection", myCollection.Type.Name);
            Assert.AreEqual("TestProject", myCollection.Type.Namespace);
            Assert.AreEqual(TypeBuilderKind.IPersistableModel, myCollection.Kind);
            Assert.AreEqual("LocalContext", myCollection.ContextType.Name);
            Assert.AreEqual("TestProject", myCollection.ContextType.Namespace);
            Assert.IsNull(myCollection.PersistableModelProxy);
        }
    }
}
