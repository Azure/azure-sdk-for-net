// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.ModelReaderWriterTests;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class ContextGeneratorTests
    {
        [TestCase("public")]
        [TestCase("internal")]
        [TestCase("private")]
        public void SingleContext(string modifier)
        {
            string source = $@"
                using System.ClientModel.Primitives;

                namespace TestProject
                {{
                    {modifier} partial class LocalContext : ModelReaderWriterContext {{ }}
                }}
                ";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.ContextFile);
            Assert.AreEqual(result.ContextFile!.Type.Name, "LocalContext");
            Assert.AreEqual(result.ContextFile.Type.Namespace, "TestProject");
            Assert.AreEqual(0, result.Diagnostics.Length);
            Assert.AreEqual(modifier, result.ContextFile!.Modifier);
            Assert.AreEqual(0, result.ContextFile.Types.Count);
            Assert.AreEqual(0, result.ContextFile.ReferencedContexts.Count);
        }

        [TestCase("public")]
        [TestCase("internal")]
        [TestCase("private")]
        public void SingleContextWithReference(string modifier)
        {
            string source = $@"
                using System.ClientModel.Primitives;

                namespace TestProject
                {{
                    {modifier} partial class LocalContext : ModelReaderWriterContext {{ }}
                }}
                ";

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
            string source = $@"
                using System.ClientModel.Primitives;

                namespace TestProject
                {{
                    public partial class LocalContext1 : ModelReaderWriterContext {{ }}
                    public partial class LocalContext2 : ModelReaderWriterContext {{ }}
                }}
                ";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.ContextFile);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, result.Diagnostics[0].Id);
        }

        [Test]
        public void NoPartialShouldFail()
        {
            string source = $@"
                using System.ClientModel.Primitives;

                namespace TestProject
                {{
                    public class LocalContext : ModelReaderWriterContext {{ }}
                }}
                ";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.ContextFile);
            Assert.AreEqual(1, result.Diagnostics.Length);
            Assert.AreEqual(ContextGenerator.DiagnosticDescriptors.ContextMustBePartial.Id, result.Diagnostics[0].Id);
        }
    }
}
