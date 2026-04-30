// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class MultipleContextAnalyzerTests
    {
        [Test]
        public async Task MultipleContextsShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext1 : ModelReaderWriterContext { }
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext2 : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNull(result.GenerationSpec);
            Assert.AreEqual(0, result.Diagnostics.Length);

            var analyzer = new MultipleContextAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(2, diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, diagnostics[0].Id);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, diagnostics[1].Id);
        }

        [Test]
        public async Task SingleContextsShouldPass()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext1 : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var result = CompilationHelper.RunSourceGenerator(compilation);

            Assert.IsNotNull(result.GenerationSpec);
            Assert.AreEqual(0, result.Diagnostics.Length);

            var analyzer = new MultipleContextAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task MultipleContextsDifferentNamespacesShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject.A
{
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext1 : ModelReaderWriterContext { }
}

namespace TestProject.B
{
    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext2 : ModelReaderWriterContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MultipleContextAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(2, diagnostics.Length);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, diagnostics[0].Id);
            Assert.AreEqual(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id, diagnostics[1].Id);
        }

        [Test]
        public async Task IndirectSubclassesShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;

namespace TestProject
{
    public abstract partial class BaseContext : ModelReaderWriterContext { }

    [ModelReaderWriterBuildable(typeof(int))]
    public partial class Context1 : BaseContext { }

    [ModelReaderWriterBuildable(typeof(int))]
    public partial class Context2 : BaseContext { }
}
""";

            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new MultipleContextAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            // BaseContext + Context1 + Context2 = 3 contexts detected
            Assert.AreEqual(3, diagnostics.Length);
            Assert.IsTrue(diagnostics.All(d =>
                d.Id == ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported.Id));
        }
    }
}
