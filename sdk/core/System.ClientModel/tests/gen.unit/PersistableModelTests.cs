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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(modifier, result.ContextFile.Modifier);
            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(1, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual("PersistableModel", result.ContextFile.TypeBuilders[0].Type.Name);
            Assert.AreEqual(modifier, result.ContextFile.TypeBuilders[0].Modifier);
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

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("LocalContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestProject", result.ContextFile.Type.Namespace);
            Assert.AreEqual(modifier, result.ContextFile.Modifier);
            Assert.AreEqual(0, result.Diagnostics.Length);

            Assert.AreEqual(1, result.ContextFile.TypeBuilders.Count);
            Assert.AreEqual("JsonModel", result.ContextFile.TypeBuilders[0].Type.Name);
            Assert.AreEqual(modifier, result.ContextFile.TypeBuilders[0].Modifier);
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

            Assert.IsNull(result.ContextFile);
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

            Assert.IsNull(result.ContextFile);
        }
    }
}
