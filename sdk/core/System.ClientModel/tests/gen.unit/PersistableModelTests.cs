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
    }
}
