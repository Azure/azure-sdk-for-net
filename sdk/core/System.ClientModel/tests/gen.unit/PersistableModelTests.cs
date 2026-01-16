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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.Modifier, Is.EqualTo(modifier));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));

            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("PersistableModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Modifier, Is.EqualTo("internal"));
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.Modifier, Is.EqualTo(modifier));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));

            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("JsonModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Modifier, Is.EqualTo("internal"));
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

            Assert.That(result.GenerationSpec, Is.Null);
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

            Assert.That(result.GenerationSpec, Is.Null);
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.Modifier, Is.EqualTo("public"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));

            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.Name, Is.EqualTo("Wrapper.JsonModel"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Type.TypeCaseName, Is.EqualTo("Wrapper_JsonModel_"));
            Assert.That(result.GenerationSpec.TypeBuilders[0].Modifier, Is.EqualTo("internal"));

            var modelType = newCompilation.GetTypeByMetadataName("TestProject.Wrapper+JsonModel");
            Assert.That(modelType, Is.Not.Null);
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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.GenerationSpec.Modifier, Is.EqualTo("public"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));

            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(0));
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

            Assert.That(depResult.GenerationSpec, Is.Null);

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

            Assert.That(result.GenerationSpec, Is.Not.Null);
            Assert.That(result.GenerationSpec!.Type.Name, Is.EqualTo("LocalContext"));
            Assert.That(result.GenerationSpec.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(result.Diagnostics.Length, Is.EqualTo(0));
            Assert.That(result.GenerationSpec!.Modifier, Is.EqualTo("public"));
            Assert.That(result.GenerationSpec.TypeBuilders.Count, Is.EqualTo(1));
            Assert.That(result.GenerationSpec.ReferencedContexts.Count, Is.EqualTo(0));

            var myCollection = result.GenerationSpec.TypeBuilders[0];
            Assert.That(myCollection.Modifier, Is.EqualTo("internal"));
            Assert.That(myCollection.Type.Name, Is.EqualTo("MyCollection"));
            Assert.That(myCollection.Type.Namespace, Is.EqualTo("TestProject"));
            Assert.That(myCollection.Kind, Is.EqualTo(TypeBuilderKind.IPersistableModel));
            Assert.That(myCollection.ContextType.Name, Is.EqualTo("LocalContext"));
            Assert.That(myCollection.ContextType.Namespace, Is.EqualTo("TestProject"));
            Assert.That(myCollection.PersistableModelProxy, Is.Null);
        }
    }
}
