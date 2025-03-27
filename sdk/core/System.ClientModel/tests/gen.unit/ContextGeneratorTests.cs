// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class ContextGeneratorTests
    {
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
            Assert.AreEqual(0, result.ContextFile.Types.Count);
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
            Assert.AreEqual(result.ContextFile!.Type.Name, "LocalContext");
            Assert.AreEqual(result.ContextFile.Type.Namespace, "TestProject");
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.Types.Count);
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
            Assert.AreEqual(ContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, result.Diagnostics[0].Id);
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
            Assert.AreEqual(ContextGenerator.DiagnosticDescriptors.ContextMustBePartial.Id, result.Diagnostics[0].Id);
        }

        [Test]
        public void AttributeOnWrongClassTypeShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public class LocalContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual("TestAssemblyContext", result.ContextFile!.Type.Name);
            Assert.AreEqual("TestAssembly", result.ContextFile.Type.Namespace);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
            Assert.AreEqual(0, result.ContextFile.Types.Count);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id, result.Diagnostics[0].Id);
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
            Assert.AreEqual(2, result.ContextFile.Types.Count);

            var dict = result.ContextFile.Types.ToDictionary(t => t.Type.Name, t => t);
            ListTests.AssertList(InvocationTestBase.JsonModel, InvocationTestBase.AssertJsonModel, dict);

            Assert.IsTrue(dict.ContainsKey(InvocationTestBase.JsonModel));
            var item = dict[InvocationTestBase.JsonModel];
            InvocationTestBase.AssertJsonModel(item.Type);

            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id, result.Diagnostics[0].Id);
        }
    }
}
