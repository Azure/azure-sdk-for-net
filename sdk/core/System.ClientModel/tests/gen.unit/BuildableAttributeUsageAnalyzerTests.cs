// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit
{
    public class BuildableAttributeUsageAnalyzerTests
    {
        [Test]
        public async Task AttributeOnNonContextClassShouldFail()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    [ModelReaderWriterBuildable(typeof(int))]
    public class NotAContext { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new BuildableAttributeUsageAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(1, diagnostics.Length);
            Assert.AreEqual(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext.Id,
                diagnostics[0].Id);
        }

        [Test]
        public async Task AttributeOnContextClassShouldPass()
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
            var analyzer = new BuildableAttributeUsageAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task NoAttributeShouldPass()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    public class NotAContext { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new BuildableAttributeUsageAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }

        [Test]
        public async Task AttributeOnIndirectSubclassShouldPass()
        {
            string source =
$$"""
using System.ClientModel.Primitives;
namespace TestProject
{
    public partial class IntermediateContext : ModelReaderWriterContext { }

    [ModelReaderWriterBuildable(typeof(int))]
    public partial class LocalContext : IntermediateContext { }
}
""";
            Compilation compilation = CompilationHelper.CreateCompilation(source);
            var analyzer = new BuildableAttributeUsageAnalyzer();
            var diagnostics = await CompilationHelper.GetAnalyzerDiagnosticsAsync(compilation, analyzer);

            Assert.AreEqual(0, diagnostics.Length);
        }
    }
}
