// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class PartialModifierAnalyzerTests
    {
        [Test]
        public async Task NoPartialShouldFail()
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
            var analyzer = new PartialModifierAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.ContextMustBePartial.Id, diagnostics[0].Id);
        }

        [Test]
        public async Task PartialShouldPass()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext : ModelReaderWriterContext { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new PartialModifierAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }
    }
}
